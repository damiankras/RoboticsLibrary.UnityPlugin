#pragma once

#ifndef NATIVE_RL_MDL_MODEL_H
#define NATIVE_RL_MDL_MODEL_H

#include "DLLExport.h"

#ifdef __cplusplus
extern "C"
{
#endif // __cplusplus

	// Model

	PINVOKELIB_API rl::mdl::Model* RL_MDL_Model_New();
	PINVOKELIB_API rl::mdl::Model* RL_MDL_XmlFactory_Create(const char* path);
	PINVOKELIB_API void RL_MDL_Model_Delete(rl::mdl::Model* model);

	PINVOKELIB_API void RL_MDL_Model_GetAcceleration(rl::mdl::Model* model, double* vector);

	PINVOKELIB_API::std::size_t RL_MDL_Model_GetDof(rl::mdl::Model* model);
	PINVOKELIB_API::std::size_t RL_MDL_Model_GetDofPosition(rl::mdl::Model* model);
	PINVOKELIB_API::std::size_t RL_MDL_Model_GetBodies(rl::mdl::Model* model);
	PINVOKELIB_API::std::size_t RL_MDL_Model_GetJoints(rl::mdl::Model* model);
	PINVOKELIB_API::std::size_t RL_MDL_Model_GetOperationalDof(rl::mdl::Model* model);

	PINVOKELIB_API void RL_MDL_Model_GetPosition(rl::mdl::Model* model, double* vector);

	PINVOKELIB_API void RL_MDL_Model_GetHomePosition(rl::mdl::Model* model, double* vector);
	PINVOKELIB_API void RL_MDL_Model_GetMaximum(rl::mdl::Model* model, double* vector);
	PINVOKELIB_API void RL_MDL_Model_GetMinimum(rl::mdl::Model* model, double* vector);
	PINVOKELIB_API void RL_MDL_Model_GetTorque(rl::mdl::Model* model, double* vector);
	PINVOKELIB_API void RL_MDL_Model_GetSpeed(rl::mdl::Model* model, double* vector);
	PINVOKELIB_API void RL_MDL_Model_GetVelocity(rl::mdl::Model* model, double* vector);

	PINVOKELIB_API void RL_MDL_Model_GetTool(rl::mdl::Model* model, double* vector);

	
#ifdef __cplusplus
}
#endif // __cplusplus

#endif // NATIVE_RL_MDL_MODEL_H