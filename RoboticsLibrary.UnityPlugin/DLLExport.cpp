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
	auto robot = GetRobot(id);
	robot.GetPosition(data);
}

void Robot_SetPosition(long id, double* data)
{
	auto robot = GetRobot(id);
	robot.SetPosition(data);
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
