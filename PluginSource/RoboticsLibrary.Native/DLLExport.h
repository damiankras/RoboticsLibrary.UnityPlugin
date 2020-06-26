#pragma once

#include "Robot.h"

#ifdef PINVOKELIB_EXPORTS
#define PINVOKELIB_API __declspec(dllexport)
#else
#define PINVOKELIB_API __declspec(dllimport)
#endif

#ifdef __cplusplus
extern "C"
{
#endif

	PINVOKELIB_API long Robot_GetDof(long id);

	PINVOKELIB_API void Robot_GetPosition(long id, double* data);
	PINVOKELIB_API void Robot_SetPosition(long id, double* data);

	PINVOKELIB_API void Robot_GetAcceleration(long id, double* data);
	PINVOKELIB_API void Robot_SetAcceleration(long id, double* data);

	PINVOKELIB_API void Robot_GetSpeed(long id, double* data);

	PINVOKELIB_API void Robot_SetGoal(long id, long tcpId, RoboticsLibrary::Transform* transform);
	PINVOKELIB_API bool Robot_SolveIk(long id);

#ifdef __cplusplus
}
#endif