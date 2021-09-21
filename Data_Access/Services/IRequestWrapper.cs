using Data_Access.Communication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<IEnumerable<T>>
{ }
public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, IEnumerable<TOut>>
    where TIn : IRequestWrapper<TOut>
{ }
}
