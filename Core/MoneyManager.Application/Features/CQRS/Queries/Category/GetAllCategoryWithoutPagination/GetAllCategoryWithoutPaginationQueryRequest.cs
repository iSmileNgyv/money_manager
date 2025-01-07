using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategoryWithoutPagination;

public class GetAllCategoryWithoutPaginationQueryRequest : IRequest<List<GetAllCategoryWithoutPaginationQueryResponse>>;