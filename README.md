# Swagger

Launch the app. Navigate to:
  - ```http://localhost:<port>/swagger ``` to view the Swagger UI.


# TODO
 - Move the logic that is responsible for generating resources identifiers from BLL to DAL. Looks like the current usage of lock statements is not valid. It will be better to use a single lock inside SaveAsync method.

```sh
public async Task<T> SaveAsync(T element)
{
    return await Task.Run(() =>
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        lock (_lockObject)
        {
            var items = GetAll();
            var existing = items?.FirstOrDefault(i => i.Id == element.Id);

            if (existing != null)
            {
                Repository.Remove(existing);
            }

            if (element.Id == 0)
            {
                element.Id = items == null || !items.Any()
                    ? IdIncrementingValue
                    : items.Select(p => p.Id).Max() + IdIncrementingValue;
            }

            Repository.Add(element);
            return element;
        }
    });
}
```