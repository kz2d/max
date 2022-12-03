using Banks.Interfaces;
using Banks.Tools.exceptions;

namespace Banks.Entitys.Transactions;

public class SendMoney : ITransaction
{
    private Func<Guid, IBill?> _maper;
    private IBill? _fromBill;
    private IBill? _toBill;
    private decimal _amount;
    private Guid _from;
    private Guid _to;
    private State _state;

    public SendMoney(Func<Guid, IBill?> maper, Guid from, Guid to, decimal amount)
    {
        _maper = maper;
        _from = from;
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

        _fromBill = _maper(_from) ?? throw new WrongBillNumber(_from.ToString());
        _toBill = _maper(_to) ?? throw new WrongBillNumber(_to.ToString());
        _fromBill.AddTransactionToHistory(this);
        _toBill.AddTransactionToHistory(this);

        _fromBill.DecreaseCash(_amount);
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

        _toBill!.EncreaseCash(_amount);
        _state = State.Completed;
    }
}