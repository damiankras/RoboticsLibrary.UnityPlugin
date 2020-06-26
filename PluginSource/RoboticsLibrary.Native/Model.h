#pragma once

#ifndef NATIVE_RL_MDL_MODEL_H
#define NATIVE_RL_MDL_MODEL_H

#include "DLLExport.h"

// ReSharper disable CppInconsistentNaming

#ifdef __cplusplus
extern "C"
{
#endif // __cplusplus

	enum errorno_codes
	{
		UNKNOWN = -1,
		SUCCESS = 0,
		NULLPTR,
		NOT_IMPLEMENTED,
		STD_BAD_ALLOC
	};

	PINVOKELIB_API errno_t RL_MDL_Model_New(_Out_ rl::mdl::Model* &ptr);

	PINVOKELIB_API errno_t RL_MDL_Model_Delete(_Inout_ rl::mdl::Model* &ptr);

	PINVOKELIB_API errno_t RL_MDL_XmlFactory_Create(
		_In_ const char* path, _Out_ rl::mdl::Model* &ptr);

	PINVOKELIB_API errno_t RL_MDL_Model_AreColliding(
		_In_ rl::mdl::Model* ptr,
		_In_ const uint64_t& i,
		_In_ const uint64_t& j,
		_Out_ uint32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetAcceleration(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetAccelerationUnits(
		_In_ rl::mdl::Model* ptr, _Out_ int32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetBodies(
		_In_ rl::mdl::Model* ptr, _Out_ uint64_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetDof(
		_In_ rl::mdl::Model* ptr, _Out_ uint64_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetDofPosition(
		_In_ rl::mdl::Model* ptr, _Out_ uint64_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetJoints(
		_In_ rl::mdl::Model* ptr, _Out_ uint64_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetOperationalDof(
		_In_ rl::mdl::Model* ptr, _Out_ uint64_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetPosition(
		_In_ rl::mdl::Model* ptr, _Out_  double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetPositionUnits(
		_In_ rl::mdl::Model* ptr, _Out_ int32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetHomePosition(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetMaximum(
		_In_ rl::mdl::Model* ptr, _Out_  double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetMinimum(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetTorque(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetTorqueUnits(
		_In_ rl::mdl::Model* ptr, _Out_ int32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetSpeed(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetSpeedUnits(
		_In_ rl::mdl::Model* ptr, _Out_ int32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetVelocity(
		_In_ rl::mdl::Model* ptr, _Out_ double* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetVelocityUnits(
		_In_ rl::mdl::Model* ptr, _Out_ int32_t* dst);

	PINVOKELIB_API errno_t RL_MDL_Model_GetTool(
		_In_ rl::mdl::Model* ptr, _In_ const uint64_t& i, _Out_ double* dst);

#ifdef __cplusplus
}
#endif // __cplusplus

#endif // NATIVE_RL_MDL_MODEL_H