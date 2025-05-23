delivery-recipient-examine = Предназначено для {$recipient}, {$job}.
delivery-already-opened-examine = Уже было открыто.
delivery-recipient-no-name = Безымянный
delivery-recipient-no-job = Неизвестный

delivery-unlocked-self = Вы открыли {$delivery} вашим отпечатком.
delivery-opened-self = Вы открыли {$delivery}.
delivery-unlocked-others = {CAPITALIZE($recipient)} распакован {$delivery} с {POSS-ADJ($possadj)} отпечаток.
delivery-opened-others = {CAPITALIZE($recipient)} открыт {$delivery}.

delivery-unlock-verb = Распаковать
delivery-open-verb = Открыть
delivery-slice-verb = Разрезать

delivery-teleporter-amount-examine =
    { $amount ->
        [one] Содержит [color=yellow]{$amount}[/color] доставку.
        *[other] Содержат [color=yellow]{$amount}[/color] доставки.
    }
delivery-teleporter-empty = {$entity} пустой.
delivery-teleporter-empty-verb = Забирать почту
