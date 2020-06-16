# frozen_string_literal: true

# Copyright 2020, John Gaskin <brotherbain@gmail.com>
#
# This file is part of LionEditor.
#
# LionEditor is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# LionEditor is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.

module Datatypes
  ZODIAC = {
    Aries: 0x00,
    Taurus: 0x10,
    Gemini: 0x20,
    Cancer: 0x30,
    Leo: 0x40,
    Virgo: 0x50,
    Libra: 0x60,
    Scorpio: 0x70,
    Sagittarius: 0x80,
    Capricorn: 0x90,
    Aquarius: 0xA0,
    Pisces: 0xB0,
    Serpentarius: 0xC0
  }.freeze

  GENDER = {
    Monster: 0x20,
    Female: 0x40,
    Male: 0x80
  }.freeze
end
