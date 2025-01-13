using MoneyManager.Application.Repositories.Media;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Media;

public class MediaReadRepository(MainContext context) : ReadRepository<Domain.Entities.Media>(context), IMediaReadRepository;