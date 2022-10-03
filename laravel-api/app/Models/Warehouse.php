<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Warehouse extends Model
{
    use HasFactory;

    public function BlackSmith(){
        return $this -> hasMany(BlackSmith::class);
    }

    public function Generalstore(){
        return $this -> hasMany(Generalstore::class);
    }

    public function Recepie(){
        return $this -> hasMany(Recepie::class);
    }
}
