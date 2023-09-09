﻿namespace EventBud.Domain.Common;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public Guid Id { get; } = Guid.NewGuid();

    public static bool operator ==(BaseEntity? first, BaseEntity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(BaseEntity? first, BaseEntity? second)
    {
        return !(first == second);
    }
    
    public bool Equals(BaseEntity? other)
    {
        if (other is null) return false;

        if (other.GetType() != GetType()) return false;

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not BaseEntity baseEntity) return false;

        return baseEntity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}