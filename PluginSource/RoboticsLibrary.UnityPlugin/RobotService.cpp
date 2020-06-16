#include "RobotService.h"
#include <iostream>

namespace RoboticsLibrary
{
	RobotService::RobotService()
	{
#ifdef DEBUG_OUTPUT
		std::cout << "RobotService" << std::endl;
#endif
	};

	RobotService::~RobotService()
	{
#ifdef DEBUG_OUTPUT
		std::cout << "~RobotService" << std::endl;
#endif
	};

	static std::shared_ptr<RobotService> shared_instance;
	static long m_lastId = 0;

	std::shared_ptr<RobotService> RobotService::Instance()
	{
		if (shared_instance == nullptr)
		{
			const auto service = new RobotService();
			shared_instance = std::shared_ptr<RobotService>(service);
		}

		return shared_instance;
	}

	long RobotService::CreateRobot(std::string pathToMdl)
	{
		const auto ptr = std::make_shared<Robot>(pathToMdl);
		const long id = ++m_lastId;
		m_robotsMap[id] = ptr;
		return id;
	}

	Robot& RobotService::GetRobot(long id)
	{
		const auto ptr = m_robotsMap[id].get();
		return *ptr;
	}

	bool RobotService::DeleteRobot(long id)
	{
		const long erased = m_robotsMap.erase(id);
		return erased > 0;
	}
}