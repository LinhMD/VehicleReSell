﻿
namespace CrudApiTemplate.Repository;

public interface IUnitOfWork : IDisposable
{
    public void Add<T>(IRepository<T> repository) where T : class;

    public IRepository<T> Get<T>() where T : class;

    public IRepository<object> Get(Type modelType);

    int Complete();

    Task<int> CompleteAsync();
}