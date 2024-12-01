using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Category;

public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>;