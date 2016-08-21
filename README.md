# olist

Manage a list of strings in Windows Console.


## usage

```batch
> olist [options] <function> <args>...
:: [-i|--input <input list>]
:: [-s|--input-separator <separator>] (multi)
:: [-t|--argment-separator <separator>] (multi)
:: [-u|--output-separator <separator>] (multi)
:: separators: default value is new-line (\r\n, \n, \r)

:: [] -> optional argument
:: <> -> argument value
```


### size

```batch
:: get size of list
> olist [options] size
```

```batch
:: get no. of items in your grocery list
> olist -i "cake.milk.butter.parle-g" -s "."

:: get no. of movies in movie list
> type movie_list.txt | olist size
```


### get

```batch
:: get values in list
> olist [options] get [<begin>] [<end>]
```

```batch
:: get 1st question for Kaun Banega Crorepati
> type kbc.txt | olist get

:: get 2nd question (5th line) in KBC
> type kbc.txt | olist get 4

:: get 4 options for the 1st question (2nd to 5th lines)
> type kbc.txt | olist get 1 5
```


### set

```batch
:: set/overwrite values in list
> olist [options] set [<value>] [<begin>] [<end>]
```

```batch
:: modify the 1st line in whatsapp code
> type whatsapp.c | olist set "/*" > whatsapp.c

:: modify 5th line in the code
> type whatsapp.c | olist set " * All Duties Reserved." 4 > whatsapp.c

:: empty out the license (lines 1-22) in code
> type whatsapp.c | olist set "" 0 21 > whatsapp.c
```


### add

```batch
:: add/insert values in list
> olist [options] add [<values>] [<offset>] [<num>]
```

```batch
:: add cooking mutton jhol to the end of your goals
> type goal.txt | olist add "Cooking Mutton Jhol" > goal.txt

:: add kicking vikram to goals in rank 23
> type goal.txt | olist add "Kicking Vikram" 22 > goal.txt

:: add 3 ideas to to goals at 27th position
> type goal.txt | olist -t "#" add "Shocking Sandal#Audio Sandal#Heat Sandal" 26

:: create a 1000 line motivation list
> echo.| olist add "Dream -> Thoughts -> Action" 0 1000 > motiv.txt
```


### remove

```batch
:: remove/delete values in list
> olist [options] remove [<begin>] [<end>]
```

```batch
:: remove the last location from your tour list
> type tour.txt | olist remove > tour.txt

:: remove 8th item from the tour list
> type tour.txt | olist remove 7 > tour.txt

:: remove 8th to 13th items from the tour list
> type tour.txt | olist remove 7 13 > tour.txt
```

### reverse

```batch
:: reverse part of list
> olist [options] reverse [<begin>] [<end>]
```

```batch
:: find how a tune sounds when played reverse
> type titanic.tune | olist reverse > titanic.tune

:: reverse a tune from the middle (584th line) to end
> type titanic.tune | olist reverse 583 > titanic.tune

:: reverse only a part of tune (584th to 606th line)
> type titanic.tune | olist reverse 583 606 > titanic.tune
```


### find

```batch
:: find indexes of value in list
> olist [options] find [<value>]
```

```batch
:: find the index of a news article
> type news.txt | olist find "Air Force Plane Missing"

:: find the index of a news article, with another possible name
> type news.txt | olist -t ":" find "Air Force Plane Missing:29 Army Men Missing"
```


### replace

```batch
:: find and replace values in list
> olist [options] replace [<find value>] [<replace value>]
```

```batch
:: remove Anjali from your call log
> type call.log | olist replace "Anjali" > call.log

:: replace Anjali with Mama in call log
> type call.log | olist replace "Anjali" "Mama" > call.log

:: replace Anjali/Rohini with Mama in call log
> type call.log | olist -t ";" replace "Anjali;Rohini" "Mama" > call.log

:: replace Anjali/Rohini with Mama and Bhouni
> type call.log | olist -t ";" -t "," replace "Anjali,Rohini" "Mama;Bhouni" > call.log
```


### sort

```batch
:: sort list in ascending order
> olist [options] sort
```

```batch
:: sort your friends' birthdays by date (yyyy.mm.dd : name)
> type bday.txt | olist sort > bday.txt
```
