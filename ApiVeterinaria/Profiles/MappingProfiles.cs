using ApiVeterinaria.Dtos;
using Dominio.Entities;
using AutoMapper;
using API.Dtos;

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

        CreateMap<Medicamento, MovimientoMedicamentoDto>().ReverseMap();

        CreateMap<Cita, CitaVeterinarioDto>().ReverseMap();
        
        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();

        CreateMap<Raza, RazaDto>().ReverseMap();

        CreateMap<Medicamento, laboMedicamentoDto>().ReverseMap();

        CreateMap<Laboratorio, MedicamentoLaboDto>().ReverseMap();

        CreateMap<Medicamento, Medicamento5000Dto>().ReverseMap();

        CreateMap<Mascota, MascotaVacunadaDto>().ReverseMap();

        CreateMap<MovimientoMedicamento, MedicamentoMovimientoDto>().ReverseMap();

        CreateMap<Mascota, MascotaAtendidaVeteDto>().ReverseMap();

        CreateMap<Cita, CitasDto>().ReverseMap();

        CreateMap<Laboratorio, LaboratorioDeterMedicDto>().ReverseMap();

        CreateMap<Propietario, PropietarioMascotaDto>().ReverseMap();

        CreateMap<Mascota, MascotaPropietarioDto>().ReverseMap();

        CreateMap<Especie, EspecieMascotaDto>().ReverseMap();

        CreateMap<Cita, CitaGetDto>().ReverseMap();

        CreateMap<Cliente, ClienteGetDto>().ReverseMap();

        CreateMap<Laboratorio, LaboratorioGetDto>().ReverseMap();

        CreateMap<Mascota, MascotaGetDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoGetDto>().ReverseMap();

        CreateMap<MovimientoMedicamento, MovimientoMedicamentoGetDto>().ReverseMap();

        CreateMap<MovimientoProducto, MovimientoProductoGetDto>().ReverseMap();

        CreateMap<Propietario, PropietarioGetDto>().ReverseMap();

        CreateMap<Raza, RazaGetDto>().ReverseMap();

        CreateMap<TipoMovimiento, TipoMovimientoGetDto>().ReverseMap();

        CreateMap<TratamientoMedico, TratamientoMedicoGetDto>().ReverseMap();

        CreateMap<Veterinario, VeterinarioGetDto>().ReverseMap();
    }
}
