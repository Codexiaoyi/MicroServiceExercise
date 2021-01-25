using System;

namespace GeekTime.Domain.Abstractions
{
    /// <summary>
    /// 实体存在多个id
    /// </summary>
    public interface IEntity
    {
        object[] GetKeys();
    }

    /// <summary>
    /// 实体只有一个id
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
