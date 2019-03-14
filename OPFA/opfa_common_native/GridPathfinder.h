#pragma once
#include "GridNode.h"
#include "Bytefuser.h"

#pragma region Open Node Comparer Struct
struct functor_fh
{
	bool operator()(const std::pair<uint32_t, node_packet*>& left_pair,
		const std::pair<uint32_t, node_packet*>& right_pair) const
	{
		if (left_pair.second->m_f_cost < right_pair.second->m_f_cost)
		{
			return false;
		}
		else if (left_pair.second->m_f_cost == right_pair.second->m_f_cost)
		{
			if (left_pair.second->m_h_cost <= right_pair.second->m_h_cost)
			{
				return false;
			}
		}
		return true;
	}
};
#pragma endregion

#pragma region Grid Pathfinder Class
class GridPathfinder
{
private:
	//from layout
	uint8_t m_base_cost;
	uint16_t m_width;
	uint16_t m_height;
	uint8_t m_grid_path_type;
	float m_diagonal_modifier;
	uint8_t* p_inbuffer;
	//from memory
	int32_t m_outbuffer_size;
	uint32_t* p_outbuffer;
	bool m_target_changed = false;
	//start and target
	uint16_t m_start_x;
	uint16_t m_start_y;
	uint16_t m_target_x;
	uint16_t m_target_y;
	uint32_t m_start_fxy;
	uint32_t m_target_fxy;
	//adjecent offsets
	int32_t offsets[8][2] = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }, { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
	uint8_t m_offset_count;
	//data structures - on stack
	std::unordered_map<uint32_t, GridNode> creation_map;
	boost::heap::fibonacci_heap<std::pair<uint32_t, node_packet*>, boost::heap::compare<functor_fh>> open_queue;
	std::unordered_set<uint32_t> closed_set;
	//state indicators
	std::atomic<bool> producing_frame = false;
	//mutex for lock
	std::mutex mtx;
	//internal subroutines
	int32_t produce_frame_normal();
	int32_t produce_frame_diagonal_weighted();
	int32_t construct_path();
	void ready_next_frame();
public:
	int32_t produce_frame();
	void reinit(uint8_t grid_path_type, float diagonal_modifier, int32_t outbuffer_size, 
		uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y);
	GridPathfinder(uint8_t base_cost, uint16_t width, uint16_t height, uint8_t grid_path_type, float diagonal_modifier, uint8_t* inbuffer,
		int32_t outbuffer_size, uint32_t* outbuffer, uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y);
	~GridPathfinder();
};
#pragma endregion