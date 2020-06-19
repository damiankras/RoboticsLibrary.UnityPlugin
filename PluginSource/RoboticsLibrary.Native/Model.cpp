#include "Model.h"

rl::mdl::Model* RL_MDL_Model_New()
{
	return new rl::mdl::Model();
}

void RL_MDL_Model_Delete(rl::mdl::Model* model)
{
	if (model != nullptr)
	{
		delete model;
		model = nullptr;
	}
}

rl::mdl::Model* RL_MDL_XmlFactory_Create(const char* path)
{
	try
	{
		rl::mdl::XmlFactory factory;
		const auto model_ptr = factory.create(path);
		return model_ptr;
	}
	catch (const std::exception& ex)
	{
	}
	return nullptr;
}

::std::size_t RL_MDL_Model_GetDof(rl::mdl::Model* model)
{
	//if (model == nullptr)
	//	throw

	return model->getDof();
}

::std::size_t RL_MDL_Model_GetDofPosition(rl::mdl::Model* model)
{
	//if (model == nullptr)
	//	throw

	return model->getDofPosition();
}

void RL_MDL_Model_GetAcceleration(rl::mdl::Model* model, double* vector)
{
	auto source = model->getAcceleration();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetPosition(rl::mdl::Model* model, double* vector)
{
	auto source = model->getPosition();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetHomePosition(rl::mdl::Model* model, double* vector)
{
	auto source = model->getHomePosition();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

::std::size_t RL_MDL_Model_GetBodies(rl::mdl::Model* model)
{
	return model->getBodies();
}

::std::size_t RL_MDL_Model_GetJoints(rl::mdl::Model* model)
{
	return model->getJoints();
}

::std::size_t RL_MDL_Model_GetOperationalDof(rl::mdl::Model* model)
{
	return model->getOperationalDof();
}

void RL_MDL_Model_GetMaximum(rl::mdl::Model* model, double* vector)
{
	auto source = model->getMaximum();
	size_t size = source.size();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetMinimum(rl::mdl::Model* model, double* vector)
{
	auto source = model->getMinimum();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetTorque(rl::mdl::Model* model, double* vector)
{
	auto source = model->getTorque();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetSpeed(rl::mdl::Model* model, double* vector)
{
	auto source = model->getSpeed();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetVelocity(rl::mdl::Model* model, double* vector)
{
	auto source = model->getVelocity();
	memcpy(vector, source.data(), source.size() * sizeof(double));
}

void RL_MDL_Model_GetTool(rl::mdl::Model* model, double* vector)
{
	auto tool = model->tool(0);
	tool.data();
}
