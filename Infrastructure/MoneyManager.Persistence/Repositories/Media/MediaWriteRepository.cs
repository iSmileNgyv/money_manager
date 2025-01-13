using MoneyManager.Application.Repositories.Media;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Media;

public class MediaWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Media>(context), IMediaWriteRepository;