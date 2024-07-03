﻿namespace MobyLabWebProgramming.Core.BaseObjects;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public void UpdateTime() => UpdatedAt = DateTime.UtcNow;
}
