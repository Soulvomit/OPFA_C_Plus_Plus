#pragma once
#include "Common.h"
//globals
#define NULL_HIGH_32	0x0000'0000'FFFF'FFFF
#define NULL_LOW_32		0xFFFF'FFFF'0000'0000
#define NULL_HIGH_16	0x0000'FFFF
#define NULL_LOW_16		0xFFFF'0000

static inline uint32_t Fuse(const uint16_t high, const uint16_t low)
{
	const uint32_t high16 = static_cast<const uint32_t>(high << 16);
	const uint32_t fusion = high16 | low;
	return fusion;
}
static inline uint64_t Fuse(const uint32_t high, const uint32_t low)
{
	const uint64_t high32 = static_cast<const uint32_t>((uint64_t)high << 32);
	const uint64_t fusion = high32 | low;
	return fusion;
}
static inline void Unfuse(const uint32_t fusion, uint16_t& high, uint16_t& low)
{
	high = (fusion & NULL_LOW_16) >> 16;
	low = fusion & NULL_HIGH_16;
}
static inline void Unfuse(const uint64_t fusion, uint32_t& high, uint32_t& low)
{
	high = (fusion & NULL_LOW_32) >> 32;
	low = fusion & NULL_HIGH_32;
}
static inline uint16_t UnfuseLow(const uint32_t fusion)
{
	return fusion & NULL_HIGH_16;
}
static inline uint32_t UnfuseLow(const uint64_t fusion)
{
	return fusion & NULL_HIGH_32;
}
static inline uint16_t UnfuseHigh(const uint32_t fusion)
{
	return (fusion & NULL_LOW_16) >> 16;
}
static inline uint32_t UnfuseHigh(const uint64_t fusion)
{
	return (fusion & NULL_LOW_32) >> 32;
}