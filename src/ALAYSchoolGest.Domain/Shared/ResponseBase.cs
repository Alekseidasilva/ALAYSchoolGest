﻿using Flunt.Notifications;

namespace ALAYSchoolGest.Domain.Shared;

public abstract class ResponseBase
{
    public string Message { get; set; } = String.Empty;
    public int Status { get; set; } = 400;
    public bool IsSuccess => Status is > 200 and <= 299;
    public IEnumerable<Notification>? Notifications { get; set; }
}
