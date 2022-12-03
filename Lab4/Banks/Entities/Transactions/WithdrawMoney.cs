using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys.Transactions;

public class WithdrawMoney : ITransaction
{
    private Func<Guid, IBill?> _maper;
    private IBill? _fromBill;
    private decimal _amount;
    private Guid _from;
    private State _state;

    public WithdrawMoney(Func<Guid, IBill?> maper, Guid from, decimal amount)
    {
        _maper = maper;
        _from = from;
        _amount = amount;
        _state = State.Initialized;
    }

    public void Start()
    {
        if (_state != State.Initialized)
        {
            throw new WrongTransactionSequence();
        }

        _fromBill = _maper(_from) ?? throw new WrongBillNumber(_from.ToString());
        _fromBill.DecreaseCash(_amount);
        _fromBill.AddTransactionToHistory(this);

        _state = State.Started;
    }

    public void Abort()
    {
        if (_state != State.Started)
        {
            throw new WrongTransactionSequence();
        }

        _fromBill!.EncreaseCash(_amount);
        _state = State.Completed;
    }

    public void Complete()
    {
        if (_state != State.Started)
        {
            throw new WrongTransactionSequence();
        }

        _state = State.Completed;
    }
}