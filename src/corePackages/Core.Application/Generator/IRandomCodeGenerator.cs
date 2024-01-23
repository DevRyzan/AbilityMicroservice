namespace Core.Application.Generator;

public interface IRandomCodeGenerator
{
    string GenerateUniqueCodeWithDateTime();

    string GenerateUniqueCode();

    string GenerateUniqueCodeNumberWithDateTime();

    string GenerateUniqueCodeNumber();
}

