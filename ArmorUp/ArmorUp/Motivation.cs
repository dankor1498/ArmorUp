﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArmorUp
{
    public struct Quote
    {
        public string Words { get; set; }
        public string Author { get; set; }
    }

    public static class Motivation
    {
        public static Quote[] Quotes =
        {
            new Quote { Words = "Дойдя до конца, люди смеются над страхами, мучившими их вначале", Author = "Пауло Коэльо" },
            new Quote { Words = "Если ты не знаешь, чего хочешь, ты в итоге останешься с тем, чего точно не хочешь.", Author = "Чак Паланик"},
            new Quote { Words = "Чтобы дойти до цели, надо идти.", Author = "Оноре де Бальзак" },
            new Quote { Words = "Это своего рода забава, делать невозможное.", Author = "Уолт Дисней" },
            new Quote { Words = "Если люди не смеются над вашими целями, значит ваши цели слишком мелкие.", Author = "Азим Премжи" },
            new Quote { Words = "Пробуйте и терпите неудачу, но не прерывайте ваших стараний.", Author = "Стивен Каггва" },
            new Quote { Words = "К черту все! Берись и делай!", Author = "Ричард Брэнсон" },
            new Quote { Words = "Мы сами должны стать теми переменами, которые хотим видеть в мире.", Author = "Махатма Ганди" },
            new Quote { Words = "Препятствия – это те страшные вещи, которые вы видите, когда отводите глаза от цели.", Author = "Генри Форд" },
            new Quote { Words = "Постановка целей является первым шагом на пути превращения мечты в реальность.", Author = "Тони Роббинс" },
            new Quote { Words = "Быть самым богатым человеком на кладбище для меня не важно… Ложиться спать и говорить себе, что сделал действительно нечто прекрасное, - вот что важно!", Author = "Стив Джобс" },
            new Quote { Words = "Через осуществление великих целей человек обнаруживает в себе и великий характер, делающий его маяком для других.", Author = "Георг Гегель" },
            new Quote { Words = "Мы должны вызывать, а не ждать вдохновения, чтобы начать дело. Действие всегда порождает вдохновение. Вдохновение редко порождает действие.", Author = "Фрэнк Тиболт" },
            new Quote { Words = "Когда вы знаете, чего хотите, и вы хотите этого достаточно сильно, вы найдете способ получить это.", Author = "Джим Рон" },
            new Quote { Words = "Я трачу почти все свое время на Facebook. У меня практически нет времени на новые увлечения. Поэтому я ставлю перед собой четкие цели.", Author = "Марк Цукенберг" },
            new Quote { Words = "Чтобы достичь поставленных целей, нужны терпение и энтузиазм. Мыслите глобально – но будьте реалистами.", Author = "Дональд Трамп" },
            new Quote { Words = "Самый опасный яд – чувство достижения цели. Противоядие к которому – каждый вечер думать, что можно завтра сделать лучше.", Author = "Ингвар Кампрад" },
            new Quote { Words = "Пуля, просвистевшая на дюйм от цели, так же бесполезна, как та, что не вылетала из дула.", Author = "Фенимор Купер" },
            new Quote { Words = "Никогда, никогда не позволяйте другим убедить вас, что что-то сложно или невозможно.", Author = "Дуглас Бадлер" },
            new Quote { Words = "Успех обычно приходит к тем, кто слишком занят, чтобы его просто ждать.", Author = "Генри Девид Торо" },
            new Quote { Words = "Чтобы достичь успеха, перестаньте гнаться за деньгами, гонитесь за мечтой.", Author = "Тони Шей" },
            new Quote { Words = "Секрет успешной жизни — это понять, что вам предназначено делать, и делать это.", Author = "Генри Форд" },
            new Quote { Words = "Успех — это сумма небольших усилий, повторяющихся изо дня в день.", Author = "Роберт Кольер" },
            new Quote { Words = "Я не знаю, что является ключом к успеху, но ключ к неудаче — это желание всем угодить.", Author = "Билл Косби" },
            new Quote { Words = "Успешные люди делают то, что неуспешные не хотят делать. Не стремитесь, чтобы было легче, стремитесь, чтобы было лучше.", Author = "Джим Рон" },
            new Quote { Words = "Стремитесь быть не просто успешным человеком, а ценным.", Author = "Альберт Эйнштейн" },
            new Quote { Words = "Одна победа не ведет к успеху, в отличие от постоянного желания побеждать.", Author = "Винс Ломбарди" },
            new Quote { Words = "Осуществляйте свои мечты, или кто-то наймет вас для осуществления своих.", Author = "Фарра Грей" },
            new Quote { Words = "Свой успех я объясняю вот тем, что я никогда не оправдывалась и не слушала оправданий.", Author = "Флоренс Найтингейл" },
            new Quote { Words = "Успех — это движение от неудачи к неудаче без потери энтузиазма.", Author = "Уинстон Черчилль" },
            new Quote { Words = "Успех - это лестница, на нее не взобраться, держа руки в карманах.", Author = "Пауль Баует" },
            new Quote { Words = "Успех - это успеть.", Author = "Марина Цветаева" },
            new Quote { Words = "Успех - дело чистого случая. Это вам скажет любой неудачник.", Author = "Эрл Уилсон" },
            new Quote { Words = "Успех – не ключ к счастью. Счастье – это ключ к успеху. Если вы любите то, что вы делаете, вы будете иметь успех.", Author = "Герман Каин" },
            new Quote { Words = "Успех — это баланс. Успех — это когда вы являетесь тем, чем вы можете быть, не жертвуя ничем другим в вашей жизни.", Author = "Ларри Уингет" },
            new Quote { Words = "Успех часто бывает единственной видимой разницей между гением и безумием.", Author = "Пьер Клод Буаст" },
            new Quote { Words = "Секрет жизненного успеха: будь готов к возможности до того, как она возникнет.", Author = "Бенджамин Дизраэли" },
            new Quote { Words = "Всякая работа трудна до времени, пока ее не полюбишь, а потом она возбуждает и становится легче.", Author = "Максим Горький" },
            new Quote { Words = "Выбери профессию, которую ты любишь, — и тебе не придется работать ни дня в твоей жизни.", Author = "Конфуций" },
            new Quote { Words = "Гениальность может оказаться лишь мимолетным шансом. Только работа и воля могут дать ей жизнь и обратить ее в славу.", Author = "Альберт Камю" },
            new Quote { Words = "Жить — значит работать. Труд есть жизнь человека.", Author = "Вольтер" },
            new Quote { Words = "Постарайтесь получить то, что любите, иначе придется полюбить то, что получили.", Author = "Бернард Шоу" },
            new Quote { Words = "Работа, которую мы делаем охотно, исцеляет боли.", Author = "Уильям Шекспир" },
            new Quote { Words = "Делай что можешь, с тем, что у тебя есть, там, где ты находишься.", Author = "Теодор Рузвельт" },
            new Quote { Words = "Всегда помните о том, что ваша решимость преуспеть важнее всего остального.", Author = "Авраам Линкольн" },
            new Quote { Words = "Кто хочет – ищет возможности. Кто не хочет – ищет причины.", Author = "Сократ" },
            new Quote { Words = "Любовь и работа - единственные стоящие вещи в жизни. Работа - это своеобразная форма любви.", Author = "Мэрилин Монро" },
            new Quote { Words = "Есть только один вид работы, который не вызывает депрессии, — это работа, которую ты не обязан делать.", Author = "Жорж Элгози" },
            new Quote { Words = "Я твердо верю в удачу, и я заметил: чем больше я работаю, тем я удачливее.", Author = "Томас Джефферсон" },
            new Quote { Words = "Вдохновение приходит только во время работы.", Author = "Габриэль Маркес" },
            new Quote { Words = "Понуждай сам свою работу; не жди, чтобы она тебя понуждала.", Author = "Бенджамин Франклин" },
            new Quote { Words = "Если вы будете работать для настоящего, то ваша работа выйдет ничтожной; надо работать имея в виду только будущее.", Author = "Антон Чехов" },
            new Quote { Words = "Кто делает не больше того, за что ему платят, никогда не получит больше того, что он получает.", Author = "Элберт Хаббард" },
            new Quote { Words = "Обычно те, кто лучше других умеет работать, лучше других умеют не работать.", Author = "Жорж Элгози" },
            new Quote { Words = "Самая тяжелая часть работы — решиться приступить к ней.", Author = "Габриэль Лауб" },
            new Quote { Words = "Самый несчастный из людей тот, для кого в мире не оказалось работы.", Author = "Томас Карлейль" },
            new Quote { Words = "Лучше работать без определенной цели, чем ничего не делать.", Author = "Сократ" },
            new Quote { Words = "Кто хочет сдвинуть мир, пусть сдвинет себя!", Author = "Сократ" },
            new Quote { Words = " Мы находим в жизни только то, что сами вкладываем в нее.", Author = "Ральф Уолдо Эмерсон" },
            new Quote { Words = "Пока у тебя есть попытка - ты не проиграл!", Author = "Сергей Бубка" },
            new Quote { Words = "Последняя степень неудачи — это первая ступень успеха.", Author = "Карло Досси" },
            new Quote { Words = "Неудача - это просто возможность начать снова, но уже более мудро.", Author = "Генри Форд" },
            new Quote { Words = "Я этого хочу. Значит, это будет.", Author = "Генри Форд" },
            new Quote { Words = "Если ты рожден без крыльев, не мешай им расти.", Author = "Коко Шанель" },
            new Quote { Words = "Будь собой! Прочие роли уже заняты.", Author = "Оскар Уайлд" },
            new Quote { Words = "Я не терпел поражений. Я просто нашёл 10 000 способов, которые не работают.", Author = "Томас Эдисон" },
            new Quote { Words = "Если проблему можно разрешить, не стоит о ней беспокоиться. Если проблема неразрешима, беспокоиться о ней бессмысленно.", Author = "Далай Лама" },
            new Quote { Words = "Раз в жизни фортуна стучится в дверь каждого человека, но человек в это время нередко сидит в ближайшей пивной и никакого стука не слышит.", Author = "Марк Твен" },
            new Quote { Words = "Наш большой недостаток в том, что мы слишком быстро опускаем руки. Наиболее верный путь к успеху – все время пробовать еще один раз.", Author = "Томас Эдисон" },
            new Quote { Words = "Просыпаясь утром, спроси себя: «Что я должен сделать?» Вечером, прежде чем заснуть: «Что я сделал?».", Author = "Пифагор" },
            new Quote { Words = "Бедный, неудачный, несчастливый и нездоровый это тот, кто часто использует слово "+"завтра"+".", Author = "Роберт Кийосаки" },
            new Quote { Words = "Тяжёлый труд - это скопление легких дел, которые вы не сделали, когда должны были сделать.", Author = "Джон Максвелл" },
            new Quote { Words = "Раньше я говорил: "+"Я надеюсь, что все изменится"+". Затем я понял, что существует единственный способ, чтобы все изменилось— измениться мне самому.", Author = "Джим Рон" },
            new Quote { Words = "Делай сегодня то, что другие не хотят, завтра будешь жить так, как другие не могут!", Author = "Джаред Лето" },
            new Quote { Words = "Из двух дорог лежащих предо мною – идти решил нехоженной тропой. И это в корне все переменило.", Author = "Роберт Фрост" },
            new Quote { Words = "Жизнь — как вождение велосипеда. Чтобы сохранить равновесие, ты должен двигаться.", Author = "Альберт Эйнштейн" }
        };
    }
}
