**Я нигде не оставляю ссылок на этот репозиторий и не занимаюсь его рекомендациями, все ведущие сюда ссылки оставляют возможные пользователи, а также другие люди у которых все возможно завелось и работает. Лаунчер написан на коленке, это факт, а создан только для упрощения работы людей с Zapret (для тех, кто не хочет/не может понять аргументы командных строк, кто не хочет разбираться с каждой отдельной функцией Zapret, для тех, кто хочет просто запустить и забыть), но можно лучше, сильно лучше.**

Программа предназначена для упрощения работы с Zapret. Помогает разблокировать Discord с возможностью общения в голосовых каналах, а также разблокировать YouTube и **с версии 1.0.0.5 другие необходимые вам сервисы** (по крайней мере должна помогать, я не гарантирую работоспособность чего-либо). Отличие от bat скриптов и иных для ОС Windows - упрощённая работа для пользователя благодаря незамысловатому "интерфейсу", возможность скрытия окна самого приложения в трей и скрытие окон консолей. А также доп. плюшки. 

# Важные детали
**- Для работы лаунчера требуется .NET 8+ (При запуске происходит проверка, если он не установлен - вам будет предложено загрузить .NET с официального сайта, процесс не сложный)**

**- Перед работой обязательно нужно выключить все VPN и другие средства обхода (GoodbyeDPI и подобные!)**

**- Для работы требует права администратора.**

**- Лаунчер основан на работе "Zapret": https://github.com/bol-van/zapret**
>**Огромная благодарность bol-van за его труд! (https://github.com/bol-van)**

**- Это не VPN! Запущенный в фоне лаунчер не должен увеличивать Ping и задержки.**

**- Некоторые Онлайн игры, и их античиты могут работать не корректно/не запускаться. Для исправления этого, иногда можно на время выключить запрет, и после запуска снова включить.**

# Как сделать всё быстро и запустить?
**1) Загружаем LazyDisYTUnlocker.zip из релизов: https://github.com/WutADude/LazyDiscordAndYouTubeUnlocker/releases**

**2) Распаковываем все файлы в архиве в отдельную папку** (Файл может быть один - это норма.)

**3) Запускаем от имени администратора**

**4) Внимательно читаем что требует от вас программа**

**5) Ожидаем когда кнопка запуска станет активной (на неё можно будет нажать), и жмём "Запустить"**

**Всё, проверяем работу! Если не работает - останавливаем и меняем стратегию, после чего снова проверяем.**

# Стратегии
Лаунчер при первом запуске подгрузит известные хосты сервисов и стратегии для обхода замедлений/блокировок с этого репозитория. (Стратегии добавляются вручную мной.)
То же самое делает кнопка обновления стратегий.

Также лаунчер поддерживает разделение и выбор стратегий из списка, для этого в файлах аргументы разделяются тегом **">NEW_STRATEGY"**, после которого идёт новый набор аргументов. Это позволяет делать стратегии для случаев если определённые не работают, а также позволяет удобно передавать/делиться заготовками между людьми, также это сможет помочь мне помочь вам без нужды в обновлении под каждого провайдера. Изменение стратегии происходит в один клик.

### Лаунчер не гарантирует восстановление работоспособности чего-либо! 
