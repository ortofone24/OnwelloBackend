namespace OnwelloBackend.Infrastructure
{
    public class InMemoryStore<T> where T : class
    {
        private readonly List<T> _items = new List<T>();
        private int _nextId = 1;

        private int GetId(T item)
        {
            var propertyInfo = item.GetType().GetProperty("Id");
            return (int)propertyInfo.GetValue(item);
        }

        private void SetId(T item, int id)
        {
            var propertyInfo = item.GetType().GetProperty("Id");
            propertyInfo.SetValue(item, id);
        }

        public IEnumerable<T> GetAll() => _items;

        public T GetById(int id) => _items.FirstOrDefault(item => GetId(item) == id);

        public void Add(T item)
        {
            SetId(item, _nextId++);
            _items.Add(item);
        }

        public void Update(T item)
        {
            var index = _items.FindIndex(existingItem => GetId(existingItem) == GetId(item));
            if (index != -1)
            {
                _items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(i => GetId(i) == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}
