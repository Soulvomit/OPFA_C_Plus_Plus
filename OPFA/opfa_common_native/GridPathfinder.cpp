#include "stdafx.h"
#include "GridPathfinder.h"

#pragma region Ctor/Dtor and Reinit
GridPathfinder::GridPathfinder(uint8_t base_cost, uint16_t width, uint16_t height, uint8_t grid_path_type, float diagonal_modifier,
	uint8_t* inbuffer, int32_t outbuffer_size, uint32_t* outbuffer, uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y)
{
	//layout
	m_base_cost = base_cost;
	m_width = width;
	m_height = height;
	m_grid_path_type = grid_path_type;
	m_diagonal_modifier = diagonal_modifier;
	p_inbuffer = inbuffer;
	//memory
	m_outbuffer_size = outbuffer_size;
	p_outbuffer = outbuffer;
	m_start_x = start_x;
	m_start_y = start_y;
	m_target_x = target_x;
	m_target_y = target_y;
}
GridPathfinder::~GridPathfinder()
{
	closed_set.clear();
	open_queue.empty();
	creation_map.clear();
}
void GridPathfinder::reinit(uint8_t grid_path_type, float diagonal_modifier, int32_t outbuffer_size,
	uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y) 
{
	//layout
	m_grid_path_type = grid_path_type;
	m_diagonal_modifier = diagonal_modifier;
	//memory
	m_outbuffer_size = outbuffer_size;
	m_start_x = start_x;
	m_start_y = start_y;
	if (m_target_x != target_x)
	{
		m_target_changed = true;
	}
	else if (m_target_y != target_y)
	{
		m_target_changed = true;
	}
	m_target_x = target_x;
	m_target_y = target_y;
}
#pragma endregion

#pragma region Produce Frame
int32_t GridPathfinder::produce_frame() 
{
	if (m_grid_path_type == 0)
	{
		//diagonals included
		m_offset_count = 8;
		return produce_frame_normal();
	}
	else if (m_grid_path_type == 1)
	{
		//diagonals excluded
		m_offset_count = 4;
		return produce_frame_normal();
	}
	else if (m_grid_path_type == 2)
	{
		//diagonals included
		m_offset_count = 8;
		return produce_frame_diagonal_weighted();
	}
	else
	{
		return -2;
	}
}
#pragma endregion

#pragma region Ready Next Frame
void GridPathfinder::ready_next_frame()
{
	std::map<uint32_t, GridNode>::iterator it;

	if (m_target_changed)
	{
		creation_map.clear();
		m_target_changed = false;
	}
	else
	{
		for (it = creation_map.begin(); it != creation_map.end(); it++)
		{
			it->second.get_data()->m_g_cost = 0xFF'FF'FF'FF;
			it->second.get_data()->m_f_cost = 0xFF'FF'FF'FF;
			it->second.get_data()->m_parent_fxy = 0;
		}
	}
	closed_set.clear();
	open_queue.empty();

	m_target_fxy = Fuse(m_target_x, m_target_y);

	it = creation_map.find(m_target_fxy);
	if (it != creation_map.end())
	{
		it->second.get_data()->m_h_cost = 0;
	}
	else
	{
		creation_map.emplace(std::make_pair(m_target_fxy, GridNode(m_target_x, m_target_y, (uint32_t)0)));
	}
	//create and init start
	m_start_fxy = Fuse(m_start_x, m_start_y);

	uint16_t target_xy[2] = { m_target_x, m_target_y };
	it = creation_map.find(m_start_fxy);
	if (it != creation_map.end())
	{
		creation_map[m_start_fxy] = GridNode(m_start_x, m_start_y, target_xy);
	}
	else
	{
		creation_map.emplace(std::make_pair(m_start_fxy, GridNode(m_start_x, m_start_y, target_xy)));
	}
	//insert start in open queue
	open_queue.push(std::make_pair(m_start_fxy, creation_map[m_start_fxy].get_data()));
}
#pragma endregion

#pragma region Produce Frame: Normal
int32_t GridPathfinder::produce_frame_normal()
{
	std::unordered_set<uint32_t>::iterator it_uset;
	std::map<uint32_t, GridNode>::iterator it_map;
	producing_frame = true;
	ready_next_frame();
	//while open queue is not empty
	while (open_queue.size() > 0)
	{
		//set current fused x,y to the first in open queue
		std::pair<uint32_t, node_packet*> current = open_queue.top();
		//if current is target
		if (current.second == creation_map[m_target_fxy].get_data())
		{
			//frame done, construct path
			producing_frame = false;
			return construct_path();
		}
		//pop current from queue
		open_queue.pop();
		//close the node
		closed_set.emplace(Fuse(current.second->xy[0], current.second->xy[1]));
		//foreach adjecent count
		for (int i = 0; i < m_offset_count; i++)
		{
			//calculate adjecent x,y
			uint16_t adjecent_x = current.second->xy[0] + offsets[i][0];
			uint16_t adjecent_y = current.second->xy[1] + offsets[i][1];
			//fuse adjecent x,y
			uint32_t adjecent_fxy = Fuse(adjecent_x, adjecent_y);
			//if adjecent fxy is closed
			it_uset = closed_set.find(adjecent_fxy);
			if (it_uset != closed_set.end())
			{
				//node closed, continue
				continue;
			}
			//check bounds
			if (adjecent_x >= m_width || adjecent_y >= m_height)
			{
				//adjecent x out-of-bounds, continue
				continue;
			}
			//get adjecent resistance from resistance map
			uint8_t adjecent_resistance = p_inbuffer[adjecent_x + adjecent_y * m_width]; //potential fix
			//check traversability
			if (adjecent_resistance == 0)
			{
				//adjecent resistance non-traversable, continue
				continue;
			}
			GridNode* adjecent;
			//if adjecent x,y doesn't exist
			it_map = creation_map.find(adjecent_fxy);
			if (it_map == creation_map.end())
			{
				//create node and set it as adjecent node
				creation_map.emplace(std::make_pair(adjecent_fxy, GridNode(adjecent_x, adjecent_y)));
				adjecent = &creation_map[adjecent_fxy];
			}
			else
			{
				//or, if it exists, fetch it
				adjecent = &creation_map[adjecent_fxy];
			}
			//calculate tentative path
			uint32_t tentative_g_cost = current.second->m_g_cost + adjecent_resistance;
			//if tentative path is ( longer then or same as ) current path
			if (tentative_g_cost >= adjecent->get_data()->m_g_cost)
			{
				//path is not better, continue
				continue;
			}
			//calc heuristics if not calculated
			if (adjecent->get_data()->m_h_cost == 0xFF'FF'FF'FF)
			{
				uint16_t target_xy [2] = { m_target_x, m_target_y };
				adjecent->calc_hueristic(target_xy);
				adjecent->get_data()->m_h_cost *= m_base_cost;
			}
			//update this path lengt 
			adjecent->get_data()->m_g_cost = tentative_g_cost;
			//update new path and cost
			adjecent->get_data()->m_parent_fxy = Fuse(current.second->xy[0], current.second->xy[1]);
			adjecent->get_data()->m_f_cost = tentative_g_cost + adjecent->get_data()->m_h_cost;
			//open adjecent node
			open_queue.push(std::make_pair(adjecent_fxy, adjecent->get_data()));
		}
	}
	//path could not be found
	producing_frame = false;
	return -1;
}
#pragma endregion

#pragma region Produce Frame: Diagonal Weighted
int32_t GridPathfinder::produce_frame_diagonal_weighted() 
{
	std::unordered_set<uint32_t>::iterator it_uset;
	std::map<uint32_t, GridNode>::iterator it_map;
	producing_frame = true;
	ready_next_frame();
	//while open queue is not empty
	while (open_queue.size() > 0)
	{
		//set current fused x,y to the first in open queue
		std::pair<uint32_t, node_packet*> current = open_queue.top();
		//if current is target
		if (current.second == creation_map[m_target_fxy].get_data())
		{
			//frame done, construct path
			producing_frame = false;
			return construct_path();
		}
		//pop current from queue
		open_queue.pop();
		//close the node
		closed_set.emplace(Fuse(current.second->xy[0], current.second->xy[1]));
		//foreach adjecent count
		for (int i = 0; i < m_offset_count; i++)
		{
			//calculate adjecent x,y
			uint16_t adjecent_x = current.second->xy[0] + offsets[i][0];
			uint16_t adjecent_y = current.second->xy[1] + offsets[i][1];
			//fuse adjecent x,y
			uint32_t adjecent_fxy = Fuse(adjecent_x, adjecent_y);
			//if adjecent fxy is closed
			it_uset = closed_set.find(adjecent_fxy);
			if (it_uset != closed_set.end())
			{
				//node closed, continue
				continue;
			}
			//check bounds
			if (adjecent_x >= m_width || adjecent_y >= m_height)
			{
				//adjecent x out-of-bounds, continue
				continue;
			}
			//get adjecent resistance from resistance map
			uint8_t adjecent_resistance = p_inbuffer[adjecent_x + adjecent_y * m_width]; //potential fix
			//check traversability
			if (adjecent_resistance == 0)
			{
				//adjecent resistance non-traversable, continue
				continue;
			}
			//check if the adjecent node is diagonal
			if (i > 3)
			{
				//add diagonal modifier for path smoothing
				adjecent_resistance = (uint8_t)(adjecent_resistance * m_diagonal_modifier);
			}
			GridNode* adjecent;
			//if adjecent x,y doesn't exist
			it_map = creation_map.find(adjecent_fxy);
			if (it_map == creation_map.end())
			{
				//create node and set it as adjecent node
				creation_map.emplace(std::make_pair(adjecent_fxy, GridNode(adjecent_x, adjecent_y)));
				adjecent = &creation_map[adjecent_fxy];
			}
			else
			{
				//or, if it exists, fetch it
				adjecent = &creation_map[adjecent_fxy];
			}
			//calculate tentative path
			uint32_t tentative_g_cost = current.second->m_g_cost + adjecent_resistance;
			//if tentative path is ( longer then or same as ) current path
			if (tentative_g_cost >= adjecent->get_data()->m_g_cost)
			{
				//path is not better, continue
				continue;
			}
			//calc heuristics if not calculated
			if (adjecent->get_data()->m_h_cost == 0xFF'FF'FF'FF)
			{
				uint16_t target_xy[2] = { m_target_x, m_target_y };
				adjecent->calc_hueristic(target_xy);
				adjecent->get_data()->m_h_cost *= m_base_cost;
			}
			//update this path lengt 
			adjecent->get_data()->m_g_cost = tentative_g_cost;
			//update new path and cost
			adjecent->get_data()->m_parent_fxy = Fuse(current.second->xy[0], current.second->xy[1]);
			adjecent->get_data()->m_f_cost = tentative_g_cost + adjecent->get_data()->m_h_cost;
			//open adjecent node
			open_queue.push(std::make_pair(adjecent_fxy, adjecent->get_data()));
		}
	}
	//path could not be found
	producing_frame = false;
	return -1;
}
#pragma endregion

#pragma region Construct Path
int32_t GridPathfinder::construct_path()
{
	std::unique_lock<std::mutex> lock(mtx, std::defer_lock);
	// critical section (exclusive access to std::cout signaled by locking lck):
	lock.lock();
	uint32_t next_fxy = m_target_fxy;
	int32_t counter;
	for (counter = 0; counter < m_outbuffer_size; counter++)
	{
		//fill outbuffer
		if (next_fxy == m_start_fxy)
		{
			break;
		}
		p_outbuffer[counter] = next_fxy;
		next_fxy = creation_map[next_fxy].get_data()->m_parent_fxy;
	}
	lock.unlock();
	return counter;
}
#pragma endregion