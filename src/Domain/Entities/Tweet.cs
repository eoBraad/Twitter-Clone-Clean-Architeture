﻿using Domain.Common;

namespace Domain.Entities;

public class Tweet : BaseEntity
{
    public string TweetContent { get; set; }

    public User Owner { get; set; }

    public Guid OwnerId { get; set; }

    public List<Likes> TweetLikes { get; set; }
}
