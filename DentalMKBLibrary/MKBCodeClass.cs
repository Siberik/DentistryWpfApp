using System.Collections.Generic;

public class DentalDisease
{
    public string Code { get; set; }
    public string Name { get; set; }
    // Дополнительные свойства, если необходимо
}

public static class DentalMKBClassifier
{
    public static List<DentalDisease> GetDentalDiseases()
    {
        List<DentalDisease> diseases = new List<DentalDisease>();

        diseases.Add(new DentalDisease { Code = "K01.1", Name = "Кариес эмали" });
        diseases.Add(new DentalDisease { Code = "K01.2", Name = "Кариес дентина" });
        diseases.Add(new DentalDisease { Code = "K02.1", Name = "Пульпит" });
        diseases.Add(new DentalDisease { Code = "K02.2", Name = "Периодонтит" });
        diseases.Add(new DentalDisease { Code = "K03.1", Name = "Расстройства развития зубов" });
        diseases.Add(new DentalDisease { Code = "K03.2", Name = "Дистопия зубов" });
        diseases.Add(new DentalDisease { Code = "K04.1", Name = "Стоматит" });
        diseases.Add(new DentalDisease { Code = "K04.2", Name = "Глоссит" });
        diseases.Add(new DentalDisease { Code = "K05.1", Name = "Периодонтоз" });
        diseases.Add(new DentalDisease { Code = "K05.2", Name = "Гингивит" });
        diseases.Add(new DentalDisease { Code = "K06.1", Name = "Нарушения окклюзии зубов" });
        diseases.Add(new DentalDisease { Code = "K06.2", Name = "Деформация челюстей" });
        diseases.Add(new DentalDisease { Code = "K07.1", Name = "Киста челюсти" });
        diseases.Add(new DentalDisease { Code = "K07.2", Name = "Абсцесс челюсти" });
        diseases.Add(new DentalDisease { Code = "K08.1", Name = "Злокачественная опухоль челюсти" });
        diseases.Add(new DentalDisease { Code = "K08.2", Name = "Доброкачественная опухоль челюсти" });
        diseases.Add(new DentalDisease { Code = "K09.1", Name = "Травма челюсти" });
        diseases.Add(new DentalDisease { Code = "K09.2", Name = "Вывих челюсти" });
        diseases.Add(new DentalDisease { Code = "K10.1", Name = "Патологическое смещение зубов" });
        diseases.Add(new DentalDisease { Code = "K10.2", Name = "Аномалия положения зубов" });
        diseases.Add(new DentalDisease { Code = "K11.1", Name = "Резорбция корней зубов" });
        diseases.Add(new DentalDisease { Code = "K11.2", Name = "Эрозия эмали зубов" });
        diseases.Add(new DentalDisease { Code = "K12.1", Name = "Дефект фиссуры" });
        diseases.Add(new DentalDisease { Code = "K12.2", Name = "Аномалия формы зубов" });
        diseases.Add(new DentalDisease { Code = "K13.1", Name = "Альвеолит" });
        diseases.Add(new DentalDisease { Code = "K13.2", Name = "Остеомиелит челюсти" });
        diseases.Add(new DentalDisease { Code = "K14.1", Name = "Синдром атрофии челюстей" });
        diseases.Add(new DentalDisease { Code = "K14.2", Name = "Синдром дистрофии челюстей" });
        diseases.Add(new DentalDisease { Code = "K15.1", Name = "Пародонтит" });
        diseases.Add(new DentalDisease { Code = "K15.2", Name = "Гиперплазия десны" });
        diseases.Add(new DentalDisease { Code = "K16.1", Name = "Ретенция зубов" });
        diseases.Add(new DentalDisease { Code = "K16.2", Name = "Эктопия зубов" });
        diseases.Add(new DentalDisease { Code = "K17.1", Name = "Дефект зубной эмали" });
        diseases.Add(new DentalDisease { Code = "K17.2", Name = "Гипоплазия эмали" });
        diseases.Add(new DentalDisease { Code = "K18.1", Name = "Синдром коронки зуба" });
        diseases.Add(new DentalDisease { Code = "K18.2", Name = "Дефект коронки зуба" });
        diseases.Add(new DentalDisease { Code = "K19.1", Name = "Дефект зубного корня" });
        diseases.Add(new DentalDisease { Code = "K19.2", Name = "Перфорация корневого канала" });
        diseases.Add(new DentalDisease { Code = "K20.1", Name = "Дефект зубного пульпы" });
        diseases.Add(new DentalDisease { Code = "K20.2", Name = "Воспаление зубной пульпы" });
        diseases.Add(new DentalDisease { Code = "K21.1", Name = "Периапикальная киста" });
        diseases.Add(new DentalDisease { Code = "K21.2", Name = "Радикулярная киста" });
        diseases.Add(new DentalDisease { Code = "K22.1", Name = "Периапикальный абсцесс" });
        diseases.Add(new DentalDisease { Code = "K22.2", Name = "Радикулярный абсцесс" });
        diseases.Add(new DentalDisease { Code = "K23.1", Name = "Остеома зубной кости" });
        diseases.Add(new DentalDisease { Code = "K23.2", Name = "Цистофиброз зубной кости" });
        diseases.Add(new DentalDisease { Code = "K24.1", Name = "Геморрагия десны" });
        diseases.Add(new DentalDisease { Code = "K24.2", Name = "Гиперплазия десны" });
        diseases.Add(new DentalDisease { Code = "K25.1", Name = "Дисплазия эмали зубов" });
        diseases.Add(new DentalDisease { Code = "K25.2", Name = "Некроз зубной пульпы" });
        diseases.Add(new DentalDisease { Code = "K26.1", Name = "Кариес шейки зуба" });
        diseases.Add(new DentalDisease { Code = "K26.2", Name = "Периодонтит шейки зуба" });
        diseases.Add(new DentalDisease { Code = "K27.1", Name = "Киста зуба" });
        diseases.Add(new DentalDisease { Code = "K27.2", Name = "Абсцесс зуба" });
        diseases.Add(new DentalDisease { Code = "K28.1", Name = "Травма зуба" });
        diseases.Add(new DentalDisease { Code = "K28.2", Name = "Перелом зуба" });

        return diseases;
    }
}
