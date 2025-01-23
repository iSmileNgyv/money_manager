using MoneyManager.Application.Repositories.PaymentMethod;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.PaymentMethod;

public class PaymentMethodWriteRepository(MainContext context) : WriteRepository<Domain.Entities.PaymentMethod>(context), IPaymentMethodWriteRepository;