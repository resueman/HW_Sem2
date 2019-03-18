namespace Task2
{
    class UniqueList<T> : List<T>
    {
        public override void AddNode(T value)
        {
            if (GetPositionByValue(value) == -1)
            {
                throw new AddExistingNodeException("Such key already exists");
            }
            base.AddNode(value, 1);
        }

        public override void DeleteNode(T value)
        {
            var position = GetPositionByValue(value);
            if (position == -1)
            { 
                throw new DeleteNonExistentNodeException("No such key");
            }
            base.DeleteNodeByPosition(position);
        }
    }
}
