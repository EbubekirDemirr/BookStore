﻿namespace Entities.Concrete.Models.GetModels;

public class GetByIdBookDTO
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public string PageCount { get; set; }
    public string Description { get; set; }
}
