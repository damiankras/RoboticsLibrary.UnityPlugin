#include "Robot.h"

RoboticsLibrary::Robot::Robot(std::string &pathToMdl)
{
	rl::mdl::XmlFactory factory;

	const auto model_ptr = factory.create(pathToMdl);
	const std::shared_ptr<rl::mdl::Model> model(model_ptr);
	m_model = model;

	//std::shared_ptr<rl::mdl::Dynamic> dynamics
	//	= std::dynamic_pointer_cast<rl::mdl::Dynamic>(model);

	std::shared_ptr<rl::mdl::Kinematic> kinematic
		= std::dynamic_pointer_cast<rl::mdl::Kinematic>(model);

	m_nlopt_ik = std::make_shared<rl::mdl::NloptInverseKinematics>(kinematic.get());
}

RoboticsLibrary::Robot::~Robot() = default;

rl::mdl::Model& RoboticsLibrary::Robot::GetModel()
{
	return *m_model;
}

size_t RoboticsLibrary::Robot::GetDof() const
{
	return m_model->getDof();
}

void RoboticsLibrary::Robot::GetPosition(double* data) const
{
	const size_t dof = GetDof();
	auto pos = m_model->getPosition();
	for (size_t i = 0; i < dof; i++)
	{
		data[i] = pos[i];
	}
}

void RoboticsLibrary::Robot::SetPosition(const double* data)
{
	const size_t dof = GetDof();
	auto pos = rl::math::Vector(dof);
	for (size_t i = 0; i < dof; i++)
	{
		pos[i] = data[i];
	}
	m_model->setPosition(pos);
}

void RoboticsLibrary::Robot::SetGoal(size_t tcpId, Transform &transform)
{
	rl::math::Transform rl_transform = rl::math::Transform();

	rl_transform.linear() = (
		rl::math::AngleAxis(transform.Rotation.z, rl::math::Vector3::UnitZ()) *
		rl::math::AngleAxis(transform.Rotation.y, rl::math::Vector3::UnitY()) *
		rl::math::AngleAxis(transform.Rotation.x, rl::math::Vector3::UnitX())
		).toRotationMatrix();

	auto translation = rl_transform.translation();
	translation(0) = transform.Translation.x;
	translation(1) = transform.Translation.y;
	translation(2) = transform.Translation.z;

	m_nlopt_ik->goals.emplace_back(rl_transform, tcpId);
}

void RoboticsLibrary::Robot::ClearGoals()
{
	m_nlopt_ik->goals.clear();
}

bool RoboticsLibrary::Robot::SolveIk()
{
	const bool isSolved = m_nlopt_ik->solve();
	ClearGoals();
	return isSolved;
}