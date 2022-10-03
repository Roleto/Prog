<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Generalstore extends Model
{
    use HasFactory;
    
    public function Warehouse(){
        return $this -> belongsTo(Warehouse::class);
    }
}
