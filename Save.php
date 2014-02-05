<?php

require_once("config.php");

$auth_host = $GLOBALS['auth_host'];
$auth_user = $GLOBALS['auth_user'];
$auth_pass = $GLOBALS['auth_pass'];
$auth_dbase = $GLOBALS['auth_dbase'];

$db = mysql_connect($auth_host, $auth_user, $auth_pass) or die ("Keine Verbindung moeglich");
mysql_select_db($auth_dbase) or die ("Die Datenbank existiert nicht.");

$query = mysql_insert("account",$_POST);
mysql_query($query); 

mysql_close($db);
?>

<?php
function mysql_insert($table, $inserts) {
    $values = array_map('mysql_real_escape_string', array_values($inserts));
    $keys = array_keys($inserts);
        
    return mysql_query('INSERT INTO `'.$table.'` (`'.implode('`,`', $keys).'`) VALUES (\''.implode('\',\'', $values).'\')');
}
?>
