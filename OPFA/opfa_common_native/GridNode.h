#pragma once
#include "Common.h"

#pragma pack(push, 1)
struct node_packet
{
	uint32_t m_f_cost = 0xFF'FF'FF'FF;
	uint32_t m_g_cost = 0xFF'FF'FF'FF;
	uint32_t m_h_cost = 0xFF'FF'FF'FF;
	uint32_t m_parent_fxy = 0;
	uint16_t xy[2];
};
#pragma pack(pop)

class GridNode
{
private:
	node_packet m_data;
	uint32_t h_diagonal_distance(uint16_t* target);
	uint32_t h_manhatten_distance(uint16_t* target);
public:
	//public members
	GridNode()
	{
	}
    GridNode(uint16_t x, uint16_t y)
	{
		m_data.xy[0] = x;
		m_data.xy[1] = y;
	}
	GridNode(uint16_t x, uint16_t y, uint32_t customHCost)
	{
		m_data.xy[0] = x;
		m_data.xy[1] = y;
		m_data.m_h_cost = customHCost;
	}
	GridNode(uint16_t x, uint16_t y, uint16_t* target)
	{
		m_data.xy[0] = x;
		m_data.xy[1] = y;
		m_data.m_g_cost = 0;
		calc_hueristic(target);
		m_data.m_f_cost = m_data.m_h_cost;
	}

	void calc_hueristic(uint16_t* target);
	node_packet* get_data();
};