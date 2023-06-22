﻿namespace CrudApiTemplate.Request;

public class PagingRequest
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}