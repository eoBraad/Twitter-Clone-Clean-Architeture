﻿using Domain.Common;

namespace Domain.Entities;

public class Likes : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid TweetId { get; set; }
    public Tweet Tweet { get; set; }
    public User User { get; set; }
}
