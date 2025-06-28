﻿namespace AccountingLedgerSystem.Application.DTOs
{
    public class AccountCreateRequestDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
    }
}
