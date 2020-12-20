using UnityEngine.AI;

namespace FSM
{
    public class StateMachine : AbstractStateMachine
    {
        private DataHolder _dataHolder;

        public DataHolder DataHolder
        {
            get => _dataHolder;
            set => _dataHolder = value;
        }

        public StateMachine(DataHolder dataHolder)
        {
            DataHolder = dataHolder;
        }
    }
}