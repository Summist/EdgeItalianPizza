using EdgeItalianPizza.Domain.Enums;

namespace EdgeItalianPizza.Application.DTOs;

public record class ResultDto<T>(T Body, Status Status) where T : class;
