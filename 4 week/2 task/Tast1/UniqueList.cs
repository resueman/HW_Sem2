namespace Task2
{
    public class UniqueList<T> : List<T>, IUniqueList<T>
    {
        public void AddNode(T value)
        {
            if (GetPositionByValue(value) != -1)
            {
                throw new AddExistingNodeException("Such key already exists");
            }
            AddNode(value, 1);
        }

        public void DeleteNode(T value)
        {
            var position = GetPositionByValue(value);
            if (position == -1)
            { 
                throw new DeleteNonExistentNodeException("No such key");
            }
            DeleteNodeByPosition(position);
        }
    }
}
