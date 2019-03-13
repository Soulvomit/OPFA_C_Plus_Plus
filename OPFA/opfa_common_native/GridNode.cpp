#include "stdafx.h"
#include "GridNode.h"

void GridNode::calc_hueristic(uint16_t* target)
{
	m_data.m_h_cost = h_diagonal_distance(target);
	return;
}
uint32_t GridNode::h_diagonal_distance(uint16_t* target)
{
	uint32_t xd = abs(m_data.xy[0] - target[0]);
	uint32_t yd = abs(m_data.xy[1] - target[1]);
	if (xd > yd)
	{
		return (14 * yd + 10 * (xd - yd));
	}
	else
	{
		return (14 * xd + 10 * (yd - xd));
	}
}
uint32_t GridNode::h_manhatten_distance(uint16_t* target)
{
	return 10 * (abs(m_data.xy[0] - target[0]) + abs(m_data.xy[0] - target[1]));
}
node_packet* GridNode::get_data()
{
	return &m_data;
}