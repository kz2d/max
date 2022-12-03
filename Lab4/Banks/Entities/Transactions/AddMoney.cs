using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys.Transactions;

public class AddMoney : ITransaction
{
    private Func<Guid, IBill?> _maper;
    private IBill? _toBill;
    private decimal _amount;
    private Guid _to;
    private State _state;

    public AddMoney(Func<Guid, IBill?> maper, Guid to, decimal amount)
    {
        _maper = maper;
        _to = to;
        _amount = amount;
        _state = State.Initialized;
    }

    public void Start()
    {
        if (_state != State.Initialized)
        {
            throw new WrongTransactionSequence();
        }

        _toBill = _maper(_to) ?? throw new WrongBillNumber(_to.ToString());
        _toBill.AddTransactionToHistory(this);

        _state = State.Started;
    }

    public void Abort()
    {
        if (_state != State.Started)
        {
            throw new WrongTransactionSequence();
        }

        _state = State.Completed;
    }

    public void Complete()
    {
        if (_state != State.Started)
        {
            throw new WrongTransactionSequence();
        }

        _toBill!.EncreaseCash(_amount);
        _state = State.Completed;
    }
}