#pragma once

#include "Robot.h"

#define DEBUG_OUTPUT 1

namespace RoboticsLibrary
{
	class RobotService
	{
	private:
		std::map<long, std::shared_ptr<Robot>> m_robotsMap;
		RobotService();

	public:
		static std::shared_ptr<RobotService> Instance();

		long CreateRobot(std::string pathToMdl);
		Robot& GetRobot(long id);
		bool DeleteRobot(long id);

	public:
		~RobotService();
	};
}