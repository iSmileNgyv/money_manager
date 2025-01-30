namespace MoneyManager.Application.Exceptions.Cashback;

public class CashbackInUseErrorException(): BaseException("Silə bilməzsiniz çünki istifadə olunur", 422);