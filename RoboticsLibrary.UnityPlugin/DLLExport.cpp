#include "DLLExport.h"

RoboticsLibrary::Robot& GetRobot(long id)
{
	return RoboticsLibrary::RobotService::Instance()->GetRobot(id);
}

long CreateRobot(const char * pathToMdl)
{
	long id = -1;
	try
	{
		std::string path = std::string(pathToMdl);
		id = RoboticsLibrary::RobotService::Instance()->CreateRobot(path);
	}
	catch (const std::exception& ex)
	{
	}

	return id;
}

void CopyData(const rl::math::Vector &source, double *destination, size_t lenght)
{
	for (size_t i = 0; i < lenght; i++)
	{
		destination[i] = source[i];
	}
}

void CopyData(const double *source, rl::math::Vector &destination, size_t lenght)
{
	for (size_t i = 0; i < lenght; i++)
	{
		destination[i] = source[i];
	}
}

bool DeleteRobot(long id)
{
	return RoboticsLibrary::RobotService::Instance()->DeleteRobot(id);
}

long Robot_GetDof(long id)
{
	auto robot = GetRobot(id);
	return robot.GetDof();
}

void Robot_GetPosition(long id, double* data)
{
	auto model = GetRobot(id).GetModel();
	const size_t dof = model.getDof();
	CopyData(model.getPosition(), data, dof);
}

void Robot_SetPosition(long id, double* data)
{
	auto model = GetRobot(id).GetModel();
	const size_t dof = model.getDof();
	auto pos = rl::math::Vector(dof);
	CopyData(data, pos, dof);
	model.setPosition(pos);
}

void Robot_GetAcceleration(long id, double* data)
{
	auto model = GetRobot(id).GetModel();
	const size_t dof = model.getDof();
	CopyData(model.getAcceleration(), data, dof);
}

void Robot_SetAcceleration(long id, double* data)
{
	auto model = GetRobot(id).GetModel();
	const size_t dof = model.getDof();
	auto pos = rl::math::Vector(dof);
	CopyData(data, pos, dof);
	model.setAcceleration(pos);
}

void Robot_SetGoal(long id, long tcpId, RoboticsLibrary::Transform* transform)
{
	auto robot = GetRobot(id);
	robot.SetGoal(tcpId, *transform);
}

bool Robot_SolveIk(long id)
{
	auto robot = GetRobot(id);
	return robot.SolveIk();
}