using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;

public class GetAllMediaQueryRequest : IRequest<List<GetAllMediaQueryResponse>>;