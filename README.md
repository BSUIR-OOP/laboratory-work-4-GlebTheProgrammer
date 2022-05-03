# laboratory-work-4-GlebTheProgrammer

Создать библиотеку с dependency injection контейнером, который способен создавать:
А)Singleton сервис(для одного потока, в многопоточность не лезем)
Б)Transient сервис -> каждый вызов - создание нового объекта

Программа должна уметь:
- работать как с вашими сервисами, так и со стандартными классами .Net.
- обрабатывать вложенные зависимости
- выбрасывать кастомную ошибку при наличии циклической зависимости (s1 -> s2 -> s1, s1-> s2 -> s3 -> s1, etc.. любая степень вложенности)

Результат работы должен представлять из себя сборку из двух проектов.
1ый проект - библиотека c DI контейнером
2ой проект - тестовый проект с результатом работы контейнера(например, консольное приложение с вариантами использования, 
либо тестовый проект с юнит тестами, покрывающие функционал библиотеки)

