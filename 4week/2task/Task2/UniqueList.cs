namespace Task2
{
    /// <summary>
    /// Structure that stores unique values
    /// </summary>
    /// <typeparam name="T">Type of stored data</typeparam>
    public class UniqueList<T> : List<T>
    {
        public override void Add(T value)
        {
            if (GetPositionByValue(value) != -1)
            {
                throw new AddExistingNodeException("Such key already exists");
            }
            Add(value, 1);
        }

        public override void Add(T value, int position)
        {
            if (GetPositionByValue(value) != -1)
            {
                throw new AddExistingNodeException("Such key already exists");
            }
            Add(value, position);
        }

        public void Delete(T value)
        {
            var position = GetPositionByValue(value);
            if (position == -1)
            {
                throw new DeleteNonExistentNodeException("No such key");
            }
            DeleteByPosition(position);
        }

        public override void SetValue(T value, int position)
        {
            if (GetPositionByValue(value) != -1)
            {
                throw new ImpossibleSetException("Such key already exists");
            }
            base.SetValue(value, position);
        }
    }
}
