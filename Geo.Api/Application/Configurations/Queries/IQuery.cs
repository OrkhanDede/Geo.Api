﻿using MediatR;

namespace Geo.Api.Application.Configurations.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}