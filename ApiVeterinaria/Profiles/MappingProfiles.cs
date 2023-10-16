using ApiVeterinaria.Dtos;
using Dominio.Entities;
using AutoMapper;

namespace ApiVeterinaria.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cita, CitaDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();

        CreateMap<Mascota, MascotaDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoVentaDto>().ReverseMap();

        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();

        CreateMap<Propietario, PropietarioDto>().ReverseMap();

        CreateMap<Especie, EspecieDto>().ReverseMap();

        CreateMap<MovimientoMedicamento, MovimientoMedicamentoDto>().ReverseMap();

        CreateMap<Cita, CitaVeterinarioDto>().ReverseMap();
        
        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();

        CreateMap<Raza, RazaDto>().ReverseMap();
    }
}
