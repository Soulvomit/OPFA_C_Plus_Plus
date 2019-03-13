// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "GridPathfinder.h"

std::map<uint32_t, GridPathfinder*> pathfinder_batch;

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
		break;
    case DLL_THREAD_ATTACH:
		break;
    case DLL_THREAD_DETACH:
		break;
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

extern "C" __declspec(dllexport) void Init(int32_t index, uint8_t base_cost, uint16_t width, uint16_t height, 
	uint8_t grid_path_type, float diagonal_modifier, uint8_t* inbuffer, int32_t outbuffer_size, uint32_t* outbuffer, 
	uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y)
{
	GridPathfinder* p_gp = new GridPathfinder(base_cost, width, height, grid_path_type, diagonal_modifier, inbuffer, 
		outbuffer_size, outbuffer, start_x, start_y, target_x, target_y);

	pathfinder_batch.emplace(index, p_gp);
}

extern "C" __declspec(dllexport) void Reinit(int32_t index, uint8_t grid_path_type, float diagonal_modifier, int32_t outbuffer_size,
	uint16_t start_x, uint16_t start_y, uint16_t target_x, uint16_t target_y)
{
	return pathfinder_batch[index]->reinit(grid_path_type, diagonal_modifier, outbuffer_size, start_x, start_y, target_x, target_y);
}

extern "C" __declspec(dllexport) int32_t ProduceFrame(int32_t index) 
{
	return pathfinder_batch[index]->produce_frame();
}

extern "C" __declspec(dllexport) void Free(int32_t index)
{
	delete pathfinder_batch[index];
	pathfinder_batch.erase(index);
}

extern "C" __declspec(dllexport) void FreeBatch()
{
	pathfinder_batch.clear();
}