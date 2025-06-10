# loadtesting

[English](README.md) | [Русский](README.ru.md)

## Архитектура

Примерная архитектура модуля для нагрузочного тестирования представлена ниже:

![loadtesting-architecture](../docs/img/loadtesting-architecture.png)

В данном примере оркестратор не реализуется, вместо этого выполняется мануальный запуск необходимых приложений.

## Процесс нагрузочного тестирования 

Общая диаграмма, иллюстрирующая увеличение количества запросов в зависимости от времени при тестировании на нагрузку, представлена на рисунке ниже:

![loadtesting-increasing-time-diagram](../docs/img/loadtesting-increasing-time-diagram.png)

### Типы тестирования на нагрузку

Возможно выделить несколько типов тестирования на нагрузку:
- Разовое повышение
- Константная нагрузка
- Постепенное повышение
- Скачкообразное повышение
- Флуктуационное повышение
- Рандомное повышение

В данном примере реализуется только разовое повышение и константная нагрузка.

#### Разовое повышение

Диаграмма разового повышения нагрузки:

![loadtesting-time-diagram-onetime](../docs/img/loadtesting-time-diagram-onetime.png)

Параметры для разового повышения нагрузки:

```
t1 = 0
t2 = 1
delta_min = 0
delta_max > 0
delta_r1 = 0
delta_t11 = 0
delta_t12 = 0
delta1 = 0
```

#### Константная нагрузка

Диаграмма константной нагрузки:

![loadtesting-time-diagram-constant](../docs/img/loadtesting-time-diagram-constant.png)

Параметры для константной нагрузки:

```
t1 = 0
t2 > 0
delta_min = 0
delta_max > 0
delta_r1 = 0
delta_t11 = 0
delta_t12 = 0
delta1 = 0
```

#### Постепенное повышение

Диаграмма постепенного повышения нагрузки:

![loadtesting-time-diagram-gradual](../docs/img/loadtesting-time-diagram-gradual.png)

Параметры для постепенного повышения нагрузки:

```
t1 > 0
t2 >= 0
delta_min >= 0
delta_max > 0
delta_r1 = 0
delta_t11 > 0
delta_t12 = 0
delta1 = 0
```

#### Скачкообразное повышение

Диаграмма скачкообразного повышения нагрузки:

![loadtesting-increasing-time-diagram](../docs/img/loadtesting-increasing-time-diagram.png)

Параметры для скачкообразного повышения нагрузки:

```
t1 > 0
t2 >= 0
delta_min >= 0
delta_max > 0
delta_r1 = 0
delta_t11 > 0
delta_t12 > 0
delta1 > 0
```

#### Флуктуационное повышение

Диаграмма флуктуационного повышения нагрузки:

![loadtesting-increasing-time-diagram](../docs/img/loadtesting-increasing-time-diagram.png)

Параметры для флуктуационного повышения нагрузки:

```
t1 = 0
t2 >= 0
delta_min >= 0
delta_max > 0
delta_r1 > 0
delta_t11 > 0
delta_t12 > 0
delta1 > 0
```

#### Рандомное повышение

Параметры для рандомного повышения нагрузки:

```
t1 = 0
t2 > 0
delta_min = 0
delta_max > 0
delta_r1 > 0
delta_t11 = 0
delta_t12 = 0
delta1 = 0
```
